#!/bin/bash

echo "Enter your Github API Key:"
read GH_API_KEY

dotnet pack YDotNet.sln --configuration Release

dotnet nuget push "YDotNet\bin\Release\YDotNet.1.0.0.nupkg" --source "github" --api-key "$GH_API_KEY"
dotnet nuget push "native\YDotNet.Native.Win32\bin\Release\YDotNet.Native.Win32.0.4.0.nupkg" --source "github" --api-key "$GH_API_KEY"
