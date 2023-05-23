#!/bin/sh
pushd /repos/mickeypi
commit=$(git rev-parse HEAD)
printf "Local commit $commit\n"
remotecommit=$(git ls-remote --heads -q | grep -E "[[:space:]]refs/heads/main" | cut -f1)
printf "Remote commit $remotecommit\n"
pid=$(pgrep mickey)

if(test -n "$pid")
then
    printf "Mickey is running. Shutting it down\n"
    kill $pid
fi

if(localcommit != remotecommit)
then
    printf "Updating...\n"
    git pull
    chmod +x update.sh
    printf "Updated\n"
else
    printf "Up to date\n"
fi

if(test -n "$pid")
then
    printf "Starting Mickey\n"
    /home/hallipr/.dotnet/dotnet run --project /repos/mickeypi/mickey &
fi
```
