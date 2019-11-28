import axios from "axios";

//Default baseURL for my localhost is at port 5001 at least for my .netcore backend.
export default axios.create({
  baseURL: "https://localhost:5001/api"
});
