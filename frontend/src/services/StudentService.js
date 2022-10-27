import http from "./https.js";

class StudentService {
  get() {
    return http.get('/Student/Get');
  }
  

  create(data) {
    return http.post('/Create', data);
  }

  update(id, data) {
    return http.put('/Update/${id}', data);
  }

  delete(ra) {
    return http.delete("/Student/Delete",  { params: { ra: ra} });
  }

  findByRA(ra) {
    return http.get('/Student/Get/ra', { params: { ra: ra} });
  }
}

export default new StudentService();