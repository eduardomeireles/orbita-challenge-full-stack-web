<template>
  <div class="about pa-6">
    <v-form ref="form" class="mx-2" lazy-validation>
      <v-container fluid>
        <v-row no-gutters style="height: 50px;" class="mt-4">
          <v-col cols="3">
            <v-card class="pa-2 mt-2 grey lighten-5" outlined tile>
              Nome
            </v-card>
          </v-col>
          <v-text-field class="pl-2" v-model="student.name" label="Informe o nome completo" hide-details="auto"
            :rules="rules.required" required>
          </v-text-field>
        </v-row>
        <v-row no-gutters style="height: 50px;" class="mt-4">
          <v-col cols="3">
            <v-card class="pa-2 mt-2 grey lighten-5" outlined tile>
              E-mail
            </v-card>
          </v-col>
          <v-text-field class="pl-2" v-model="student.email" label="Informe apenas um e-mail" :rules="rules.Email"
            hide-details="auto" required>
          </v-text-field>
        </v-row>
        <v-row no-gutters style="height: 50px;" class="mt-4">
          <v-col cols="3">
            <v-card class="pa-2 mt-2 grey lighten-5" outlined tile>
              Registro Acadêmico
            </v-card>
          </v-col>
          <v-text-field class="pl-2" v-bind:readonly="isEdit" v-model="student.ra" label="Informe o registro acadêmico"
            :rules="rules.required" @keypress="onlyNumber" hide-details="auto">
          </v-text-field>
        </v-row>
        <v-row no-gutters style="height: 50px;" class="mt-4">
          <v-col cols="3">
            <v-card class="pa-2 mt-2 grey lighten-5" outlined tile>
              CPF
            </v-card>
          </v-col>
          <v-text-field class="pl-2" v-bind:readonly="isEdit" v-model="student.cpf" @keypress="onlyNumber" counter="11"
            :rules="rules.Cpf" maxlength="11" label="Informe o número do documento" hide-details="auto">
          </v-text-field>
        </v-row>
      </v-container>

    </v-form>

    <v-row class="pa-10">
      <v-btn elevation="2" @click="back()">Voltar</v-btn>
      <v-btn elevation="2" @click="validate()" depressed color="primary">Confirmar</v-btn>
    </v-row>

    <v-dialog v-model="dialog" max-width="500px" persistent>
      <v-card>
        <v-card-title v-html="textDialog" class="text-h5"></v-card-title>
        <v-card-actions>
          <v-spacer></v-spacer>
          <v-btn color="blue darken-1" text @click="back()">Ok</v-btn>
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
      isEdit: false,
      dialog: false,
      textDialog: '',
      student: '',
      rules: {
        required: [value => !!value || "Campo Obrigatório."],
        Email: [
          v => !!v || 'Insira um E-mail válido.',
          v => /^(([^<>()[\]\\.,;:\s@']+(\.[^<>()\\[\]\\.,;:\s@']+)*)|('.+'))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/.test(v) || 'E-mail inválido',
        ],
        Cpf: [
          v => !!v || 'Insira o CPF',
          v => (v && v.length >= 11) || 'CPF é composto por 11 dígitos.',
        ],
      },
    }
  },
  methods: {
    isEditFunction() {
      this.isEdit = !!(this.$route.params.id);
    },
    getStudent() {
      if (this.isEdit) {
        StudentService.findByRA(this.$route.params.id)
          .then((response) => {
            this.student = response.data;
          })
          .catch((e) => {
            console.log(e);
          });
      }
      else {
        this.student = {
          ra: '',
          name: '',
          email: '',
          cpf: '',
        }
      }
    },
    back() {
      this.$router.push({ name: "students" });
    },
    async save() {
      console.log(this.isEdit);
      if (this.isEdit) {
        StudentService.update(JSON.stringify(this.student)).then((response) => {
          this.textDialog = response.data.message 
        })
        .catch((e) => {
          console.log(e);
        });
      }
      else {
        StudentService.create(JSON.stringify(this.student)).then((response) => {
          this.textDialog = response.data.message
        })
        .catch((e) => {
          console.log(e);
        });
      }
      this.dialog = true;
    },
    validate() {
      if (this.$refs.form.validate()) {
        this.save();
      }
    },
    resetValidation() {
      this.$refs.form.resetValidation()
    },
    onlyNumber($event) {
      let keyCode = ($event.keyCode ? $event.keyCode : $event.which);
      if ((keyCode < 48 || keyCode > 57) && keyCode !== 46) {
        $event.preventDefault();
      }
    },
  },

  created() {
    this.isEditFunction();
  },
  mounted() {
    this.getStudent();
    this.resetValidation();
  },
}
</script>

