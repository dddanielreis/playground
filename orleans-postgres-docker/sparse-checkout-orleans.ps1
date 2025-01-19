$repoUrl = "https://github.com/dotnet/orleans.git"
$dirName = "orleans"
$files = @(
  "src/AdoNet/Shared/PostgreSQL-Main.sql"
  "src/AdoNet/Orleans.Clustering.AdoNet/PostgreSQL-Clustering.sql"
  "src/AdoNet/Orleans.Persistence.AdoNet/PostgreSQL-Persistence.sql"
  "src/AdoNet/Orleans.Reminders.AdoNet/PostgreSQL-Reminders.sql"
)

New-Item -ItemType Directory -Path $dirName | Out-Null
Set-Location $dirName

git init
git remote add origin $repoUrl

git config core.sparsecheckout true

$files | Out-File -FilePath ".git/info/sparse-checkout" -Encoding ascii

git fetch --depth=1 origin main
git checkout main

Write-Host "Sparse checkout complete. Files are located in: $(Get-Location)"