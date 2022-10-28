import http from "./https.js";

class StudentService {
  get() {
    return http.get('/Student/Get');
  }

  create(student) {
    return http.post('/Student/Create', student, { headers: { "Content-Type": "application/json" } })
  }

  update(student) {
    return http.put('/Student/Update', student, { headers: { "Content-Type": "application/json" } })
  }

  delete(ra) {
    return http.delete("/Student/Delete", { params: { ra: ra } });
  }

  findByRA(ra) {
    return http.get('/Student/Get/ra', { params: { ra: ra } });
  }
}

export default new StudentService();