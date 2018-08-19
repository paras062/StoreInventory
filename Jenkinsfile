pipeline {
  agent any
  stages {
    stage('Restore') {
      steps {
        bat 'C:\\ProgramData\\chocolatey\\bin\\nuget.exe restore "C:\\Program Files (x86)\\Jenkins\\workspace\\RevisionV1\\StoreInventory.sln"'
      }
    }
  }
}