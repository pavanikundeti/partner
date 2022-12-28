const PROXY_CONFIG = [
  {
    context: [
      "/api/weatherforecast",
      "/api/TodoItems",
      "/api/TodoLists",
    ],
    target: "https://localhost:7184",
    secure: false
  }
]

module.exports = PROXY_CONFIG;
