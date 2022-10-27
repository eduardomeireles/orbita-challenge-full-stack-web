<template>
  <div class="about">


    <v-container fluid class="grey lighten-5">
      <v-row no-gutters style="height: 50px;">
        <v-col cols="3">
          <v-card class="pa-2 mt-2" outlined tile>
            Nome
          </v-card>
        </v-col>
        <v-text-field class="pl-2"  v-model="student.name" label="Informe o nome completo" :rules="rules.required" hide-details="auto">
        </v-text-field>
      </v-row>
      <v-row no-gutters style="height: 50px;">
        <v-col cols="3">
          <v-card class="pa-2 mt-2" outlined tile>
            E-mail
          </v-card>
        </v-col>
        <v-text-field class="pl-2" v-model="student.email" label="Informe apenas um e-mail" :rules="rules.required" hide-details="auto">
        </v-text-field>
      </v-row>
      <v-row no-gutters style="height: 50px;">
        <v-col cols="3">
          <v-card class="pa-2 mt-2" outlined tile>
            Registro Acadêmico
          </v-card>
        </v-col>
        <v-text-field class="pl-2" readonly v-model="student.ra" label="Informe o registro acadêmico" :rules="rules.required"
          hide-details="auto">
        </v-text-field>
      </v-row>
      <v-row no-gutters style="height: 50px;">
        <v-col cols="3">
          <v-card class="pa-2 mt-2" outlined tile>
            CPF
          </v-card>
        </v-col>
        <v-text-field class="pl-2" v-model="student.cpf" label="Informe o número do documento" :rules="rules.required" hide-details="auto">
        </v-text-field>
      </v-row>
    </v-container>

  </div>
</template>

<script>
import StudentService from "../services/StudentService.js";

export default {
  name: 'Home',
  data() {
    return {
      title: this.$route.params,
      student: '',
      rules: {
        required: [value => !!value || "Campo Obrigatório."]
      }

    }
  },
  methods: {
    getStudent() {
      StudentService.findByRA(this.$route.params.id)
        .then((response) => {
          this.student = response.data
        })
        .catch((e) => {
          console.log(e);
        });
    },
  },
  mounted() {
    this.getStudent();
    console.log(this.student);
    // console.log(this.$route.params.id)
  },
}

</script>

<style scoped>
.container {
  max-width: 800px;
  margin-left: 0;
}

.card {
  background-color: rgb(196, 195, 195);
  padding: 2px;
}
</style>

