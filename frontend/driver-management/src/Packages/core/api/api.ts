import axios, { AxiosInstance } from "axios";

const api: AxiosInstance = axios.create({
  baseURL: "http://localhost:5000",
  timeout: 1000,
  headers: { "X-Custom-Header": "foobar" },
});

// api.interceptors.request.use(function (config) {
//   // Do something before request is sent
//   console.log("Request sent");
//   return config;
// });

export default api;
