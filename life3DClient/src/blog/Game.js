import Grid from "@material-ui/core/Grid";
import Unity, { UnityContent } from "react-unity-webgl";

function Game() {
  const unityContent = new UnityContent(
    "Build/Bulid.json",
    "Build/UnityLoader.js"
  );
  return (
    <Grid container spacing={4}>
      <Unity unityContent={unityContent} />
    </Grid>
  );
}

export default Game;
