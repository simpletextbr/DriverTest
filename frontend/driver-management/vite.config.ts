import { defineConfig } from "vite";
import react from "@vitejs/plugin-react";

// https://vitejs.dev/config/
export default defineConfig({
  server: {
    host: true,
    port: 3001,
    hmr: {
      port: 3001,
    },
  },
  plugins: [react()],
});
