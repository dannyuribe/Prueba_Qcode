<template>
    <div class="">
        <ul class="nav justify-content-end">
            <li class="nav-item">
                <router-link 
                    class="nav-link active"
                    :to="{ name: 'VehiculoPrincipal' }"
                >QCode</router-link>
            </li > 
            <li 
                class="nav-item"
                v-if="!login">
                <router-link 
                    class="nav-link"
                    :to="{ name: 'LogeoPrincipal' }"
                >Logeo</router-link>
            </li>  
            <li v-if="login">
                <router-link 
                    class="nav-link"
                    :to="{ name: 'VehiculoPrincipal' }"
                >Vehiculos</router-link>
            </li>  
            <li v-if="login">
                <router-link to="/">Carga Masiva</router-link>
            </li>           
        </ul>
    </div>
</template>

<script>
export default {
    name:'MenuComponent',
    props:{
        login:{
            type:Boolean,
            default:false
        }
    },
}
</script>

<style>

</style>