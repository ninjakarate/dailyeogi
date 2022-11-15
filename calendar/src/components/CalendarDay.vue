<template>
    <RouterLink :to="{ 
        name: 'slot-view',
        params: { day, slotDate }
        }"
    >
        <a class="day-unit">
            {{ day }}
        </a>
    </RouterLink>
</template>

<script setup lang="ts">
defineProps<{ 
    day: number,
    slotDate: string,    
}>();

</script>

<style scoped>
.day-unit {
    cursor: pointer;
    background-color: beige;
    width: 145px;
    height: 145px;
    display: flex;
    justify-content: center;
    align-items: center;
    border: solid 1px cadetblue;
    box-shadow: 2px 2px;
}
.day-unit:hover {
    transform: scale(1.15);
    z-index: 10;
}
</style>