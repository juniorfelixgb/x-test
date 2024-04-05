<template>
    <div class="crud-form">
        <h2>Agrega un nuevo permiso</h2>

        <form id="addForm">
            <label for="employeeName">Nombre de empleado:</label>
            <input type="text" id="employeeName" name="employeeName" required v-model="permission.employeeName">

            <label for="permissionType">Tipos de permisos:</label>
            <select id="permissionType" name="permissionType" v-model="permission.permissionType">
                <option disabled value="0">-- Seleccione un tipo de permiso --</option>
                <option v-for="item in permissionTypes" :key="item.id" :value="item.id">
                    {{ item.description }}
                </option>
            </select>

            <button type="button" @click="submitPermission">Agregar</button>
        </form>
    </div>
</template>

<script>
import currentAxios from '../plugins/axios';

export default {
    data() {
        return {
            permissionTypes: [],
            permission: {
                permissionType: 0,
                employeeName: ''
            },
        }
    },
    async created() {
        try {
            const response = await currentAxios.get('permissionTypes');
            this.permissionTypes = response.data;
        } catch (error) {
            console.error(error);
        }
    },
    methods: {
        async submitPermission() {
            try {
                console.log(this.permission)
                await currentAxios.post('permissions', {
                    permissionType: this.permission.permissionType,
                    employeeName: this.permission.employeeName,
                });
            } catch (error) {
                console.error(error);
            }
        }
    }
}
</script>

<style></style>