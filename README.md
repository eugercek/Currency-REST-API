# What is this?

An internship project.

Exchange rates are downloaded, parsed and saved in database with a [daemon integrated with systemd](https://github.com/eugercek/Currency-Worker).

Afterwards [a REST server](https://github.com/eugercek/Currency-REST-API) reads and serves the databse.

At the last step [a frontend](https://github.com/eugercek/Currency-Frontend) shows data.

# How to run

**Change** `services.volumes` in `docker-compose.yml`

```sh
docker-compose up
```

## Inspect database

Find hash from

```sh
docker container ls
```

```sh
docker exec -it <HASH> bash
```
