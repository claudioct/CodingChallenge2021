Start-Process -FilePath 'dotnet' -WorkingDirectory '.\CodingChallenge\' -ArgumentList 'ef','database','update'
Start-Process -FilePath 'dotnet' -WorkingDirectory '.\CodingChallenge\' -ArgumentList 'run'
Start-Process -FilePath 'docker-compose' -WorkingDirectory '.\' -ArgumentList 'up'

