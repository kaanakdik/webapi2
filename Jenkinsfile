pipeline {
    agent any

    environment {
        IMAGE_NAME = "dotnet8-ci-image"
    }

    stages {
        stage('Checkout') {
            steps {
                git url: 'https://github.com/kaanakdik/webapi2.git'
            }
        }

        stage('Build and Test inside Docker') {
            steps {
                script {
                    docker.image('mcr.microsoft.com/dotnet/sdk:8.0').inside {
                        sh 'dotnet restore'
                        sh 'dotnet build --no-restore'
                        sh 'dotnet test --no-build --logger "trx;LogFileName=test_results.trx"'
                        sh 'dotnet tool install -g trx2junit'
                        sh '~/.dotnet/tools/trx2junit **/test_results.trx'
                    }
                }
            }
        }
    }

    post {
        always {
            junit '**/test_results.xml'
        }
    }
}
