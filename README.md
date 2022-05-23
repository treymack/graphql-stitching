# GraphQL Stitching / Federation

In which we spin up examples of how each type of Supergraph implementation works to explore pros and cons of each option.

## Notes

HC V12 Stitching Notes

* If one of the domain services breaks, the gateway can still serve requests that access other domain services
  * Errors are propogated up through the gateway
* Does not seem to work with Global Object Identification (Relay feature)
* Have to specify relationships in a .graphql file
  * No intellisense that I've found yet
  * Have to refer to docs constantly
  * Wired up the 2nd relationship (list of musicians associated with a bandKey) with less stumbling blocks once pattern is in place

HC V12 Federation Notes (Polling)

* Very similar dev experience, just different place to specify relationships and update supergraph
* Same projects used in spike, env variables to switch between strategies
* Must restart the GW for downstream changes to show up in the supergraph
* Pretty easy to break the supergraph by declaring types with the same name without `extend`

HC V12 Federation Notes (Redis)

* How to get up and running with Redis locally (Windows)

  ```powershell
  scoop install redis
  redis-server & # creates a background job
  Get-Job
  ```

  ```powershell
  npm install -g redis-commander
  redis-commander
  ```

* Hot reload of the Supergraph works as advertised
  * Client does have to refresh schema, but no restart of the gateway service required
* Definitely the way to go to simplify the deployment process and avoid downtime
