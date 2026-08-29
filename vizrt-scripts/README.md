# Vizrt Scripts

Reusable Viz Artist container scripts for broadcast graphics.

## Scripts

### Text sizing

- `text-sizing/two_range_text_box.vb` — applies fixed text-box dimensions for short and long text.
- `text-sizing/dynamic_text_box.vb` — grows the text box after 50 characters, with maximum limits.

### Car rigging\n\n- `car-rigging/car_suspension_rig.vb` — builds a basic car hierarchy and drives tire rotation, steering, body lean, and vertical suspension.\n\n### Texture animation

- `texture-animation/TextureAnimationScript.vb` — animates texture position, controls X/Y scaling, and switches between vertex, linear, reflect, and spherical mapping.

## Setup

1. Add the script to the Viz Artist text container.
2. Update `TextPath` to match the target text container in your scene.
3. Confirm that the text geometry supports `GEOM*TBOX*WIDTH` and `GEOM*TBOX*HEIGHT`.
4. Send the Control Text value to the container/field used by the scene.

The current examples read text through:

```vb
Data1Text = This.Geometry.Text
```

Default target path:

```text
MAIN_SCENE*TREE*$object$TEXT
```
