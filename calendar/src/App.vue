<template>
    <section class="title">
        Varya's work calendar
    </section>
    <RouterView />
</template>

<script setup lang="ts">
import { RouterView } from 'vue-router'
</script>

<style scoped>
.title {
    display: flex;
    justify-content: center;
    padding-bottom: 30px;
    font-size: 24px;
    font-weight:600;
    color: lightseagreen;
}
</style>