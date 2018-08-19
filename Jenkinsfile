pipeline {
  agent any
  stages {
    stage('Restore_Nuget') {
      steps {
        bat 'C:\\ProgramData\\chocolatey\\bin\\nuget.exe restore "C:\\Program Files (x86)\\Jenkins\\workspace\\eInventory_BlueOcean_master-O5D5OOV4WFBJMS2NINZQPR2AO4GCVUNY6GKO3YWWDDR7EUPWCKTA\\StoreInventory.sln"'
      }
    }
    stage('MS_Rebuild') {
      steps {
        bat '"C:\\Program Files (x86)\\MSBuild\\14.0\\Bin\\amd64\\MSBuild.exe" "C:\\Program Files (x86)\\Jenkins\\workspace\\eInventory_BlueOcean_master-O5D5OOV4WFBJMS2NINZQPR2AO4GCVUNY6GKO3YWWDDR7EUPWCKTA\\StoreInventory\\StoreInventory.csproj" /t:Rebuild /p:Configuration=Release /p:OutputPath="C:\\Program Files (x86)\\Jenkins\\workspace\\eInventory_BlueOcean_master-O5D5OOV4WFBJMS2NINZQPR2AO4GCVUNY6GKO3YWWDDR7EUPWCKTA\\StoreInventory"'
      }
    }
  }
}