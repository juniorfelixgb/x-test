<template>
    <div class="crud-table">
        <h2>Listado de permisos</h2>
        <!-- Tabla para mostrar los elementos existentes -->
        <table>
            <thead>
                <th>Id</th>
                <th>Nombre</th>
                <th>Apellido</th>
                <th>Tipo de Permiso</th>
                <th>Solicitado</th>
                <th>Acciones</th>
            </thead>
            <tbody id="itemList">
                <tr v-for="permission in permissions" :key="permission.id">
                    <td>{{ permission.id }}</td>
                    <td>{{ permission.employee.firstName }}</td>
                    <td>{{ permission.employee.lastName }}</td>
                    <td>{{ permission.permissionType.description }}</td>
                    <td>{{ permission.submittedDate }}</td>
                    <td>
                        <button>Editar</button> |
                        <button>Eliminar</button>
                    </td>
                </tr>
            </tbody>
        </table>
    </div>
</template>

<script>
import currentAxios from '../plugins/axios';

export default {
    data() {
        return {
            permissions: [],
        }
    },
    async created() {
        try {
            const response = await currentAxios.get('permissions');
            this.permissions = response.data;
        } catch (error) {
            console.error(error);
        }
    }
}
</script>

<style></style>
