#!/bin/sh
BASEDIR=$(dirname $0)
printf "Script location: $BASEDIR\n"
latestRelease=$(curl -s https://api.github.com/repos/hallipr/mickeypi/releases/latest | jq .tag_name -r)
printf "Latest release: $latestRelease\n"

pushd /var/www
curl -L "https://github.com/hallipr/mickeypi/releases/download/$latestRelease/webapp.tar.gz" -o ./webapp.tar.gz
rm -rf ./webapp
tar -xzf webapp.tar.gz -C ./webapp