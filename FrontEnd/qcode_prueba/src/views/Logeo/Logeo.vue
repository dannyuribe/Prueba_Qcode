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
            v-model="autenticar.logeo"
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
  </div>
</template>

<script>
import utilidades from "@/services/Axios";

export default {
  name: "LogeoPrincipal",
  data() {
    return {
      autenticar: {
        logeo: null,
        contrasena: null,
      },
      valor: true,
    };
  },
  methods: {
    IniciarSesion() {
      if (this.autenticar.usuario != "") {
        const formData = new FormData();
            formData.append('logeo', this.autenticar.logeo);
            formData.append('contrasena', this.autenticar.contrasena);
        utilidades.PostArchivo(
            `Autenticacion/Autenticar`,formData)
          .then((respuesta) => {
            this.$emit("logeo-inicio", this.valor);
            window.localStorage.setItem("token", respuesta.data.token.result);
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
  border: 2px solid black;
}
.contInput{
  padding: 5px;
}

</style>
