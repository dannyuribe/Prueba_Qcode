<template>
  <div class="container cont">
    <h1>Logeo</h1>
    <form class="contForm">
      <div class="form-group cont-padding">
        <label for="usuarioInput">Usuario</label>
        <div class="contInput">       
          <input
            class="form-control"
            type="text"
            id="usuarioInput"
            v-model="autenticar.correo"
          />
        </div>
      </div>
      <div class="form-group cont-padding">
        <label for="contrasenaInput">Contraseña</label>
        <div class="contInput">
          <input
          class="form-control"
          type="password"
          id="contrasenaInput"
          v-model="autenticar.contrasena"
        />
        </div>        
      </div>
      <button class="btn btn-primary" @click="IniciarSesion">Ingresar</button>
    </form>
    <div>
      <router-link 
                :to="{ name: 'RegistraLogeo'}">
                Registrar
            </router-link>
    </div>
  </div>
</template>

<script>
import utilidades from "@/services/Axios";
export default {
  name: "LogeoPrincipal",
  data() {
    return {
      autenticar: {
        correo: null,
        contrasena: null,
      },
      valor: true,
    };
  },
  methods: {
    IniciarSesion() {
      if (this.autenticar.usuario != "") {

        const formData = new FormData()
          .append('correo', this.autenticar.correo)
          .append('contrasena', this.autenticar.contrasena);

        utilidades.PostArchivo(
            `Autenticacion/Autenticar`,formData)
          .then((respuesta) => {
            this.$emit("logeo-inicio", this.valor);
            window.localStorage.setItem("token", respuesta.data.token);
            this.$router.push({ path: "/" });
          })
          .catch((error) => {
            console.log("error: " + error);
          });
      }
    },
  },
};
</script>

<style>
.contForm{  
  padding: 10px;
  text-align: center;
  width: 200px;
  margin: auto;
  border-radius: 10px;
  border: 2px solid white;
}
.contInput{
  padding: 5px;
}

</style>
