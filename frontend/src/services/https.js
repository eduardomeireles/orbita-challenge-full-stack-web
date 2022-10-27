//https://localhost:7030/swagger/v1/swagger.json
import axios from "axios";

const axiosInstance = axios.create({

    baseURL: 'https://localhost:7030/api/', 

    }
)
export default axiosInstance;