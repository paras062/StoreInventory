pipeline {
  agent any
  stages {
    stage('Restore_Nuget') {
      steps {
        bat 'C:\\ProgramData\\chocolatey\\bin\\nuget.exe restore "C:\\Program Files (x86)\\Jenkins\\workspace\\RevisionV1\\StoreInventory.sln"'
      }
    }
    stage('MS_Rebuild') {
      steps {
        bat '"C:\\Program Files (x86)\\MSBuild\\14.0\\Bin\\amd64\\MSBuild.exe" "C:\\Program Files (x86)\\Jenkins\\workspace\\RevisionV1\\StoreInventory\\StoreInventory.csproj" /t:Rebuild /p:Configuration=Release /p:OutputPath="C:\\Program Files (x86)\\Jenkins\\workspace\\RevisionV1\\StoreInventory"'
      }
    }
  }
}