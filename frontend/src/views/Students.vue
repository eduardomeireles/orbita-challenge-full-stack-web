<template>
  <div class="home pa-3">
    <div>
      <v-data-table :headers="headers" :search="search" :items="students" :hide-default-footer="true" :page.sync="page"
      :items-per-page="itemsPerPage"  @page-count="pageCount = $event">
        <template v-slot:top>
          <v-row>
            <v-col cols="6">
              <v-text-field v-model="search" append-icon="mdi-magnify" label="Digite sua busca" class="mx-4">
              </v-text-field>
            </v-col>
            <v-col cols="6">
              <v-btn elevation="2" @click="back()">Adicionar Aluno</v-btn>
            </v-col>
          </v-row>
        </template>
        <template v-slot:[`item.actions`]="{ item }">
          <v-icon small class="mr-2" @click="editStudent(item.ra)">mdi-pencil</v-icon>
          <v-icon small @click="openDeleteDialog(item.ra)">mdi-delete</v-icon>
        </template>
      </v-data-table>
      <div class="text-center pt-2">
        <v-pagination v-model="page" :length="pageCount"></v-pagination>
      </div>
    </div>
    <v-dialog v-model="dialog" max-width="500px" persistent>
      <v-card>
        <v-card-title class="text-h5">Deseja apagar o aluno?</v-card-title>
        <v-card-text>Ao clicar confirmar, o registro do aluno será apagado.</v-card-text>
        <v-card-actions>
          <v-spacer></v-spacer>
          <v-btn color="red darken-1" text @click="dialog = false">Cancelar</v-btn>
          <v-btn color="blue darken-1" text @click="deleteStudent(selected)">Confirmar</v-btn>
        </v-card-actions>
      </v-card>
    </v-dialog>
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
        { text: "Registro Acadêmico", align: "start", sortable: true, value: "ra" },
        { text: "Nome", value: "name", sortable: true },
        { text: "CPF", value: "cpf", sortable: false },
        { text: "Ações", value: "actions", sortable: false },
      ],
      dialog: false,
      selected: -1,
      search: '',
      page: 1,
      pageCount: 0,
      itemsPerPage: 10,
    }
  },
  methods: {
    get() {
      StudentService.get()
        .then((response) => {
          this.students = response.data.map(this.getDisplayStudent);
          //console.log(response);
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
    openDeleteDialog(id) {
      this.selected = id;
      console.log(this.selected);
      this.dialog = true;
    },
    deleteStudent(id) {
      StudentService.delete(id)
        .then(() => {
          this.refreshList();
        })
        .catch((e) => {
          console.log(e);
        });
      this.dialog = false;
    },
    refreshList() {
      this.get();
    },
    back() {
      this.$router.push({ name: "create-student" });
    },
  },
  mounted() {
    this.get();
    console.log(this.students);
  },
}
</script>
