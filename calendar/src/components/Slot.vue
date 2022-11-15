<template >
        <a class="slot-unit"
            @click="emit('click:toggle', slot)"
        >
            {{ arr[slot-1] }}
        </a>
</template>

<script setup lang="ts">
defineProps<{ slot: number }>();

const arr = [
    '10:00-10:29',
    '10:30-10:59',
    '11:00-11:29',
    '11:30-11:59',
    '12:00-12:29',
    '12:30-12:59',
    '13:00-13:29',
    '13:30-13:59',
    '14:00-14:29',
    '14:30-14:59',
    '15:00-15:29',
    '15:30-15:59',
    '16:00-16:29',
    '16:30-16:59',
    '17:00-17:29',
    '17:30-17:59',
    '18:00-18:29',
    '18:30-18:59',
    '19:00-19:29',
    '19:30-19:59',
    '20:00-20:29',
    '20:30-20:59',
];

const emit = defineEmits<{
    (e: 'click:toggle', slot: number): void
}>()

</script>

<style scoped>
.slot-unit {
    cursor: pointer;
    background-color: beige;
    height: 55px;
    display: flex;
    justify-content: center;
    align-items: center;
    flex-basis: 49%;
    font-weight: 500;
}
</style>