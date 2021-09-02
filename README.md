# TODO
- Add migration

## What is this
A REST API that serves daily currencies.

## Docker Run
Z is for Selinux
```
docker build -t eugercek/currency-api .
docker run -p 5000:80 -v /home/umut/src/Currencies.db:/db/Currencies.db:Z eugercek/currency-api
```