import axios from "axios";

export default class Utilidades{

  static Post(url,data){
    return axios({
      method:"POST",
      url: `http://localhost:5109/${url}`,
			data: data,
      headers:{
        'Authorization': 'Bearer '+window.localStorage.getItem("token"),
        'Referrer-Policy': 'no-referrer',   
        'Content-Type': 'application/json',   
        "Accept" : "*/*"
      }
    })
  }

  static Get(url,data){
    return axios({
      method:"GET",
      url: `http://localhost:5109/${url}`,
			params: data,
      headers:{
        "Authorization": "Bearer "+window.localStorage.getItem("token"),
        "Referrer-Policy": "no-referrer",      
      }
    })
  }

  static PostArchivo(url,data,params){
    return axios({
      method:"POST",
      url: `http://localhost:5109/${url}`,
			data: data,
      params:params,
      headers:{
        'Authorization': 'Bearer '+window.localStorage.getItem("token"),
        'Referrer-Policy': 'no-referrer',   
        'Content-Type': 'multipart/form-data',   
      }
    })
  }
  
}
