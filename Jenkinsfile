pipeline {
    agent any

    environment {
        IMAGE_NAME = 'mcr.microsoft.com/dotnet/sdk:8.0'
        TEST_RESULT_DIR = 'TestResults'
        TRX_FILE = "${TEST_RESULT_DIR}/test_results.trx"
        JUNIT_XML_FILE = "${TEST_RESULT_DIR}/test_results.xml"
    }

    stages {
        stage('Checkout') {
            steps {
                git url: 'https://github.com/kaanakdik/webapi2.git'
            }
        }

        stage('Test inside .NET 8 Docker container') {
            steps {
                script {
                    docker.image(IMAGE_NAME).inside {
                        sh '''
                            dotnet restore
                            dotnet build --no-restore
                            dotnet test --no-build --logger "trx;LogFileName=${TRX_FILE}"

                            dotnet tool install -g trx2junit
                            ~/.dotnet/tools/trx2junit ${TRX_FILE}
                        '''
                    }
                }
            }
        }
    }

    post {
        always {
            junit "${JUNIT_XML_FILE}"
        }
    }
}
