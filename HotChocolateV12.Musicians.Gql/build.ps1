$imageName = 'hc-v12-musicians'

docker build -t "$($imageName):latest" .

@{
    imageName = $imageName
}
