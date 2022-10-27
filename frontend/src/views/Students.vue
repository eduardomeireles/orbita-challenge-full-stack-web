<template>
  <div class="home">
    <v-data-table :headers="headers" :items="students" disable-pagination :hide-default-footer="true">
      <template v-slot:[`item.actions`]="{ item }">
        <v-icon small class="mr-2" @click="editStudent(item.ra)">mdi-pencil</v-icon>
        <v-icon small @click="deleteStudent(item.ra)">mdi-delete</v-icon>
      </template>
    </v-data-table>
  </div>
</template>

<script>
import StudentService from "../services/StudentService.js";

export default {
  name: 'Home',
  data() {
    return {
      students: [],
      headers: [
        { text: "Registro Acadêmico", align: "start", sortable: false, value: "ra" },
        { text: "Nome", value: "name", sortable: false },
        { text: "CPF", value: "cpf", sortable: false },
        { text: "Ações", value: "actions", sortable: false },
      ],

    }
  },
  methods: {
    get() {
      StudentService.get()
        .then((response) => {
          this.students = response.data.map(this.getDisplayStudent);
          console.log(response);
        })
        .catch((e) => {
          console.log(e);
        });

    },
    getDisplayStudent(student) {
      return {
        ra: student.ra,
        name: student.name,
        email: student.email,
        cpf: student.cpf
      };
    },
    editStudent(id) {
      this.$router.push({ name: "edit", params: { id: id } });
    },

    deleteStudent(id) {
      StudentService.delete(id)
        .then(() => {
          this.refreshList();
        })
        .catch((e) => {
          console.log(e);
        });
    },
    refreshList(){
      this.get();
    },
  },
  mounted() {
    this.get();
    console.log(this.students);
  },
}
</script>
