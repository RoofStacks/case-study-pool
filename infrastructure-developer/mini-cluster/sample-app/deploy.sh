#!/bin/bash

# Function to check if a command is available
command_exists() {
  command -v "$1" >/dev/null 2>&1
}

# Function to create a Kind cluster with Ingress support
create_kind_cluster() {
  echo "Creating a local Kubernetes cluster... please wait."
  cat <<EOF | kind create cluster --config=-
kind: Cluster
name: goart
apiVersion: kind.x-k8s.io/v1alpha4
nodes:
- role: control-plane
  kubeadmConfigPatches:
  - |
    kind: InitConfiguration
    nodeRegistration:
      kubeletExtraArgs:
        node-labels: "ingress-ready=true"
  extraPortMappings:
  - containerPort: 80
    hostPort: 80
    protocol: TCP
  - containerPort: 443
    hostPort: 443
    protocol: TCP
EOF
  echo "Kind cluster created successfully."
}

# Function to install NGINX Ingress Controller
install_nginx_ingress_controller() {
  echo -n "Installing Nginx ingress controller..."
  kubectl apply -f https://raw.githubusercontent.com/kubernetes/ingress-nginx/main/deploy/static/provider/kind/deploy.yaml > /dev/null 2>&1

  # Wait for NGINX Ingress Controller to be ready
  while [[ $(kubectl -n ingress-nginx get pods -l app.kubernetes.io/component=controller -o 'jsonpath={..status.conditions[?(@.type=="Ready")].status}') != "True" ]]; do
      echo -n "."
      sleep 1
  done

  echo " Nginx Ingress Controller installed successfully."
}

# Function to deploy Helm chart for the application
deploy_helm_chart() {
  helm upgrade --install dotnet-app-release ./kubernetes/charts/dotnet-app-chart
  echo "dotnet chart is being deployed"
}

# Main function
main() {
  # Check if required commands are available
  if ! command_exists kind || ! command_exists kubectl || ! command_exists helm; then
    echo "Error: Kind, kubectl, or helm is not installed. Please install these tools before running the script."
    exit 1
  fi

  create_kind_cluster
  install_nginx_ingress_controller

  echo "Deploying application..."
  deploy_helm_chart

  echo "Application deployed successfully!"
}

# Run the main function
main
