#!/bin/sh
BASEDIR=$(dirname $0)
printf "Script location: $BASEDIR\n"
cd $BASEDIR
latestRelease=$(curl -s https://api.github.com/repos/hallipr/mickeypi/releases/latest | jq .tag_name -r)