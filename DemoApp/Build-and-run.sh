#!/bin/bash
echo "Running CSharp tests"

app_dir="./"

cd "$app_dir"

dotnet build

if [ $? -eq 0 ]; then
  echo "Build successfull."
else
  echo "Error while building app."
  exit 1
fi

if [ $# -ne 4 ]; then
  echo "Usage: $0 HOST_NAME API_KEY WEBHOOK_URL FROM_EMAIL"
  exit 1
fi

dotnet_app_path="./DemoApp.dll"

host_name="$1"
api_key="$2"
webhook="$3"
email="$4"

dotnet run --project "$app_dir/DemoApp.csproj" "$host_name" "$api_key" "$webhook" "$email"

app_exit_code=$?


echo $app_exit_code

# exit $app_exit_code;
