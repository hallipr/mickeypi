#!/bin/sh
pushd /repos/mickeypi
commit=$(git rev-parse HEAD)
printf "$(date %Y-%m-%d_%H-%M-%S) Local commit $commit\n"
remotecommit=$(git ls-remote --heads -q | grep -E "[[:space:]]refs/heads/main" | cut -f1)
printf "$(date %Y-%m-%d_%H-%M-%S) Remote commit $remotecommit\n"


if(localcommit != remotecommit)
then
  pid=$(pgrep mickey)
  if(test -n "$pid")
  then
    printf "$(date %Y-%m-%d_%H-%M-%S) Mickey is running. Shutting it down\n"
    kill $pid
  fi

  printf "$(date %Y-%m-%d_%H-%M-%S) Updating...\n"
  git pull
  chmod +x update.sh
  printf "$(date %Y-%m-%d_%H-%M-%S) Updated\n"

  if(test -n "$pid")
  then
    printf "$(date %Y-%m-%d_%H-%M-%S) Starting Mickey\n"
    /home/hallipr/.dotnet/dotnet run --project /repos/mickeypi/mickey &
  fi
else
    printf "$(date %Y-%m-%d_%H-%M-%S) Up to date\n"
fi
