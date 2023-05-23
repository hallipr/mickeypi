#!/bin/sh
BASEDIR=$(dirname $0)
printf "Script location: $BASEDIR\n"
cd $BASEDIR
commit=$(git rev-parse HEAD)
printf "$(date +%Y-%m-%d_%H:%M:%S) Local commit $commit\n"
remotecommit=$(git ls-remote --heads -q | grep -E "[[:space:]]refs/heads/main" | cut -f1)
printf "$(date +%Y-%m-%d_%H:%M:%S) Remote commit $remotecommit\n"

if [ "$commit" != "$remotecommit" ]; then
  pid=$(pgrep mickey)
  if (test -n "$pid"); then
    printf "$(date +%Y-%m-%d_%H:%M:%S) Mickey is running. Shutting it down\n"
    kill -15 $pid
  fi

  printf "$(date +%Y-%m-%d_%H:%M:%S) Updating...\n"
  git fetch
  git reset --hard origin/main
  chmod +x update.sh
  printf "$(date +%Y-%m-%d_%H:%M:%S) Updated\n"

  if (test -n "$pid"); then
    printf "$(date +%Y-%m-%d_%H:%M:%S) Starting Mickey\n"
    cd "./mickey"
    "$HOME/.dotnet/dotnet" run &> ../logs/mickey.log & disown
  fi
else
    printf "$(date +%Y-%m-%d_%H:%M:%S) Up to date\n"
fi
