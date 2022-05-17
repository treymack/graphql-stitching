try {
    Push-Location $PSScriptRoot

    $imageName = 'hc-v12-bands'

    docker build -t "$($imageName):latest" .

    @{
        imageName = $imageName
    }
}
finally {
    Pop-Location
}

