try {
    Push-Location $PSScriptRoot

    kubectl delete -f .\.k8s
    kubectl apply -f .\.k8s
}
finally {
    Pop-Location
}
