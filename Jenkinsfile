pipeline {
  agent any

  tools {
    dotnet 'dotnet8' // .NET 8 olarak değiştirildi
  }

  stages {
    stage('Checkout') {
      steps {
        git credentialsId: 'github-creds', url: 'https://github.com/kaanakdik/webapi2.git'
      }
    }

    stage('Restore') {
      steps {
        sh 'dotnet restore MyApiSolution.sln'
      }
    }

    stage('Build') {
      steps {
        sh 'dotnet build MyApiSolution.sln --no-restore'
      }
    }

    stage('Test') {
      steps {
        sh 'dotnet test MyApiSolution.sln --no-build --logger:trx'
      }
    }
  }

  post {
    always {
      junit '**/TestResults/*.trx'
    }
  }
}
