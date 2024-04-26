<script>
    import {onMount} from 'svelte';

    let communities;
    onMount(async () => {
        const response = await fetch('http://localhost:1337/api/communities');
        const data = await response.json();

        communities = data.data;
        console.log(communities);
    });
</script>

<div class="container p-6 mx-auto text-center bg-yellow-100 rounded mt-12 text-black">
    Example rendering communities from api:
    {#if communities}
        <ul>
        {#each communities as community}
            <li>{community.attributes.name} - {community.attributes.description}</li>
        {/each}
        </ul>
    {:else}
        <p>no communities</p>
    {/if}
</div>