### Version 1.0.0-beta05

Release date: 2014/11/26

#### Issues fixed
- Build: Fixed build issues due to Asset Compiler ([#116](https://github.com/SiliconStudio/paradox/issues/116)).
- Samples: Fixed various samples that didn't build since recent changes in SpriteBatch.MeasureString ([#117](https://github.com/SiliconStudio/paradox/issues/117)).
- Studio: Fixed high CPU usage due to improper WPF refreshes ([#115](https://github.com/SiliconStudio/paradox/issues/115)).

### Version 1.0.0-beta04

Release date: 2014/11/25

#### New Features
- Build: We now use OSS (OpenSource Signing) so that you can fake-sign assemblies with the same keys as ours, and use your own compiled Paradox with the official editor ([#88](https://github.com/SiliconStudio/paradox/issues/88)).
- Engine: Unified 2D and 3D rendering: `SpriteRenderer` now works with custom matrices or camera.
- Graphics: Spot light shadow maps in deferred rendering ([#96](https://github.com/SiliconStudio/paradox/issues/96)).
- Studio: Added documentation on properties of the property grid.

#### Enhancements
- Core: Add support for `ModuleInitializer` in nested types
- Graphics: Better computation of shadow maps (for both directional and spot lights).
- Graphics: Add geometric primitive for Cone.
- Engine: Several internal improvements and factorization to support upcoming `PostEffects` framework.
- Engine: Add support for filtering model selection and rendering in `ModelRenderer`.  
- Engine: `SpriteRenderer` now uses the Projection and View matrices set in the pipeline ([#96](https://github.com/SiliconStudio/paradox/issues/96)).
- Samples: Spot light shadows in DeferredLighting sample.
- Shaders: Add support for naming a child in a `pdxfx` to allow child override.
- Shaders: `cs` files generated from `pfxfx` are now using internal and nested types instead of putting everything in the root namespace.
- Shaders: Add support for declaring a namespace in a `pdxsl`, only valid and used for `ParameterKey` declarations.
- Studio: Custom enhanced title bar for all windows.

#### Issues fixed
- Assets: Textures with arbitrary size (non square and non power-of-two) are now correctly loaded.
- Engine: Fix `EntitySystem.Remove` that was destroying the hierarchy of entities.
- Graphics: Fix spot light shadow computation.
- Samples: Fix effect compilation occurring at runtime for some samples 
- Shaders: Simplify some deferred lighting shaders.
- Shaders: Don't generate an empty class for `pdxsl` files that don't declare any shader `ParameterKey`
- Studio: Fix renamed button for string-indexed dictionary that was misplaced and not working
- Studio: Fix add parameter key control filtering and mouse selection
- Studio: Fix some actions from the property grid that were not undo-able
- Studio: Some buttons were sometimes hidden where they should be visible in the property grid.

#### Breaking changes
- Asset: CastShadows, ReceiveShadows and Layer members of `ModelAsset` class are removed. They should be set in the Parameters of the `ModelAsset` behind the corresponding keys.
- Engine: Default value for ParameterKeys `LightingKeys.CastShadows` and `LightingKeys.ReceiveShadows` becomes true.
- Engine: Remove obsolete `MeshDrawHelper` file (use `GeometricPrimitive` instead), move `ToMeshDraw` method to `GeometricPrimitiveExtensions`.
- Engine: `ModelRenderer` is no longer inheritable but extensible via compositions.
- Engine: `ModelRenderer.EnableFrustrumCulling` is replaced by the extension method `ModelRenderer.AddDefaultFrustrumCulling`
- Engine: `EffectMesh` is renamed to `RenderMesh` 
- Engine: `SpriteRenderer` now requires a valid camera to be set in the pipeline.
- Engine: `CameraComponent` now uses the Z-axis as camera direction vector to compute the view matrix when `Target` entity is null.
- Shaders: Declaring a composition member in a shader class must be now prefixed with the `compose` attribute. 
- Graphics: The signature of some overloads of `SpriteBatch.Begin` have changed for better clarity and easier usage.
- Graphics: `SpriteBatch.MeasureString` now requires the size of the final render target as parameter.

#### Known Issues
- Physics: Complex convex hull decomposition can be a very long process and there is visual feedback for it.
- Physics: Convex hull shape debug shapes in game studio are not rendering very well, although the asset will be OK.

___

### Version 1.0.0-beta03

Release date: 2014/11/11

#### New Features
- Engine: Add cubemap components to place cubemaps in the scene or render them at runtime.
- Graphics: Add skybox renderer from a TextureCube (similar to background renderer).
- Graphics: Add cubemap reflections for deferred rendering.
- Graphics: Support of shadow mapping in forward rendering for spot lights. Only 1 cascade is supported at the moment.
- Samples: Add CubemapReflection sample.
- Samples: Add spot light shadow in ForwardRendering sample.
- Shaders: Add several cubemap shaders for sampling, reflection, parallax correction etc.
- UI: Add new UI element: Slider
- Website: [Paradox Forums](http://forums.paradox3d.net) has just been opened. Feel free to use it to discuss about Paradox, help each other, collaborate and show off what you did with Paradox!

#### Enhancements
- Studio: Property grids have been reworked to be more efficient and easily extendable.
- Studio: Numeric input controls have been improved.
- Physics: Physics assembly now depends on Engine (instead of the opposite). Soon Physics (and some other modules) will become optional.
- Input: Allow emulation of several touch pointers at a same time with mouse different buttons.

#### Issues fixed
- Assets: Fix shininess import from FBX files.
- Core: EnumerableExtensions.LastIndexOf() wasn't working properly ([#62](https://github.com/SiliconStudio/paradox/issues/62)).
- Game: Properly support windows with height 0 when AllowUserResizing is true ([#65](https://github.com/SiliconStudio/paradox/issues/65)).
- Game: GameForm is created with a black background, to avoid initial flickering while Windows is being initialized ([#54](https://github.com/SiliconStudio/paradox/issues/54)).
- Input: Alt+F4 is now properly working on Windows Store/Phone platforms ([#74](https://github.com/SiliconStudio/paradox/issues/74)).
- Input: Properly maps all extended keyboard keys on Windows Store/Phone platforms ([#84](https://github.com/SiliconStudio/paradox/issues/84)).
- Input: Fix several crashes and bugs in GestureRecognizers and mouse button states.
- Misc: PCL can now be used in Windows Store/Phone platforms ([#72](https://github.com/SiliconStudio/paradox/issues/72)).
- Samples: SimpleDynamicTexture was using expected screen size instead of actual screen size, resulting in incorrect picking in fullscreen mode ([#75](https://github.com/SiliconStudio/paradox/issues/75)).
- Shaders: Geometry shaders are forced to transmit SV_Position stream to pixel shaders.
- Shaders: Compositions (especially arrays) couldn't be used in child classes of the one containing their declaration. Function and member calls weren't correctly resolved.
- Studio: Fix preview and thumbnail of materials with normal map.
- Studio: Fix binding errors in the property grid ([#29](https://github.com/SiliconStudio/paradox/issues/29)).
- Studio: Fix undesired hue changes and loss of precision in extremal values in the color picker.
- Studio: Fix "Show in explorer" on assets.
- UI: UIImage borders were not properly rendered when image had Orientation.Rotated90.

#### Breaking changes
- Graphics: Remove Rotated180 and Rotated90C from ImageOrientation enumeration for code simplicity and efficiency purpose.
- Graphics: Change ImageFragment.Region type from Rectangle to RectangleF and corresponding batch draw function API (SpriteBatch/UIBatch).
- Graphics: CopyRegion now contains additional parameters for subresource indices and destination offset.
- Graphics: RasterizerState and DepthStencilState constructors are now private to match other Graphics classes. static New() should be used instead ([#83](https://github.com/SiliconStudio/paradox/issues/83)).
- Physics: Physics engine initialization has changed since now Physics is a optional module. (please check updated samples)
- Physics: Added Convex Hull simple wrap shape and complex decomposition as well.

#### Known Issues
- Physics: Complex convex hull decomposition can be a very long process and there is visual feedback for it.
- Physics: Convex hull shape debug shapes in game studio are not rendering very well, although the asset will be OK.

___

### Version 1.0.0-beta02

Release date: 2014/10/22

#### New Features
- Graphics: Add ability to unbind all the shader resources used by an effect.
- Graphics: Add Frustum culling (available in ModelRenderer.EnableFrustumCulling).

#### Enhancements
- Audio: Add overloaded Play function in SoundEffectInstance that allows the user to specify how to deal with siblings instances (play in parallel or stop them).
- Game: MicroThreads unhandled exceptions are not ignored anymore ([#47](https://github.com/SiliconStudio/paradox/issues/47)).
- Studio: Improved the different grid views in the interface.
- Visual Studio Package: Syntax highlighting now adapts to dark theme colors ([#26](https://github.com/SiliconStudio/paradox/issues/26)).

#### Issues fixed
- Audio: Fix crash in DynamicSoundEffectInstance worker thread during Dispose ([#34](https://github.com/SiliconStudio/paradox/issues/34)).
- Audio: Fix problem of AudioEmitterSoundController stopping to play when SoundEffect is shared between several components.
- Shaders: Fix ScreenPositionBase.pdxsl.
- Studio: Some crashes that could occurs when copy/pasting assets. It is also possible to copy/paste from when a package is selected in the tree view.
- Studio: Windows resize was slow in some specific cases ([#46](https://github.com/SiliconStudio/paradox/issues/46)).
- UI: Opacity is new correctly taken into account when drawing background color of UI elements ([#43](https://github.com/SiliconStudio/paradox/issues/43)).
- UI: Fix rendering problems on the Button/ToggleButton's content when setting their background color.
- Visual Studio Package: Syntax highlighting was not working properly on VS2012 ([#45](https://github.com/SiliconStudio/paradox/issues/45)).

___

### Version 1.0.0-beta01

Release date: 2014/10/17

#### Paradox is going Open Source! 

We are thrilled to announce that Paradox is going [open source on github](https://github.com/SiliconStudio/paradox)! This is an important step toward the **empowerment of game developers**. We hope that this will make you more confident in using Paradox. You will have also an unique opportunity to contribute to the project and see by yourself how Paradox engine is working.

More details at [http://paradox3d.net/blog/new-version-open-sourcing](http://paradox3d.net/blog/new-version-open-sourcing).

#### New Platforms 

 - **Windows RT/Store**
 - **Windows Phone**
 
#### New Samples

- **SimpleTerrain** that demonstrates how to generate an entity model/mesh at runtime by displaying a heightmap terrain
- **SimpleDynamicTexture** that demonstrates how to dynamically upload CPU textures to the GPU
- **RenderSceneToTexture** that shows how to render your models in a render target from another camera point of view and display in a texture

#### New Features
- Assets: Materials can be compiled into a shader without being attached to a mesh. Use the key MaterialAsset.GenerateShader in your pdxfxlib file to allow this feature.
- Engine: Add support for Windows Store and Windows Phone projects.
- Misc: Assemblies are now all signed.
- Studio: Create Windows Store and Phone Projects.
- Studio: Deploy Windows Phone project directly from Game Studio.
- Studio: Add and remove platforms of existing game. Force to regenerate platform specific projects.
- Studio: Choose what platforms to create when starting from a sample.
- UI: Add support for MouseOver on Windows (mainly MouseOverState property/event in UIElement)

#### Enhancements
- Samples: Load material and lighting configuration for the stand in ForwardLighting and DeferredLighting.
- Shaders: Incorrect shaders are no longer cached preventing NullReferenceException errors at compilation time.
- Studio: Generated solutions are created with VS2013 as default.
- Studio: The 'sprite' editor can now be used on UIImages too.
- UI: Improve default design of Button and EditText.
- UI: Make the EditText's caret blink and dissociate caret/selection colors.
- UI: Add support for mouse selection in EditText on Windows.
- UI: Create default design for ImageToggle.
- UI: UIImages are now regrouped into UIImageGroup the same way as SpriteGroup. The runtime-time and assets classes share the same hierarchy.

#### Issues fixed
- Assets: Orientation of meshes from the assimp importer is now correct ([#22](https://github.com/SiliconStudio/paradox/issues/22)).
- Assets: Mesh and materials are correctly associated during assimp import.
- Materials: Material always contains a diffuse part even if their color is black.
- Samples: Exhaustive shaders permutations for DeferredLighting.
- Shaders: The default shader is correct even when there is no parameter to generate it (no diffuse, no specular...).
- Shaders: Fix specular in deferred shading.
- Shaders: Correctly rename class in AmbientMapShading.pdxsl.
- Shaders: Fix issues related to geometry shader creation.
- Studio: New LightingAsset asset can be created in GameStudio.
- Studio: Unsupported assets are ignored when trying to be imported ([#42](https://github.com/SiliconStudio/paradox/issues/42)).
- Studio: Fix issue with asset thumbnails sometimes not being updated.
- Studio: Some properties of the Material assets displayed with wrong/missing controls.
- UI: Fix problem in Canvas MeasureOverride method when measured with infinite values.

#### Breaking changes
- Assets: SpriteGroup asset field 'Sprites' has been renamed 'Images' (.pdxsprite files can recovered by renaming the field inside the file).
- Assets: UIImage assets does not exist any more and have been replaced UIImageGroup assets. The old .pdxuiimg files cannot be easily recovered. The new .pdximage files can be easily created using the GameStudio 'sprite' editor.
- UI: EditText's EditInactiveImage and EditActiveImage properties have been renamed InactiveImage and ActiveImage.
- UI: Simplify ToggleButton. It now behaves like a Button with persistent states.

#### Known Issues
- iOS: On slow phones, app might be too slow to start with Visual Studio attached (it gets killed by iOS). We will rearrange our initialization sequence.
- iOS: Rebuild might sometime not use latest version.
- Samples: Due to the way we now create platform-specific projects, samples specific icons on non-Windows platforms are currently gone. Later, a project setting page in Game Studio should make this setting available again.
- Samples: Since there is no accelerometer Input API yet, Accelerometer sample is currently removed.
- Windows Store/Phone: UI EditText and Game Resume/Destroy cycles are not implemented.
- Windows Store/Phone: SharpFont.dll is still compiled against .NET 4.5 (might not pass certifications).

___

### Version 1.0.0-alpha11

Release date: 2014/10/10

#### Issues fixed
- Graphics: OpenGL ES rendering was broken due to a bug in Vertex Array Object.
- iOS: GraphicsDevice.UpdateSubresource() was using wrong OpenTK overload on iOS ([#35](https://github.com/SiliconStudio/paradox/issues/35)).
- iOS: libcore.a has been recompiled with libc++, to make it compatible with iOS 7+ ([#37](https://github.com/SiliconStudio/paradox/issues/37)).
- Shaders: Remove culture-dependant shader instanciation ([#38](https://github.com/SiliconStudio/paradox/issues/38)).

___

### Version 1.0.0-alpha10

Release date: 2014/10/06

#### New Features
- Studio: Cut/copy/paste assets and asset directories (also works between different instances of Paradox Studio).

#### Enhancements
- Assets: Allow to use materials with missing Texture references at runtime (nodes with missing reference are replaced by black color node).
- Assets: Increase FBX importer robustness to unsupported features (Log potential problems instead of failing).
- Assets: Improve Assimp importer to have a similar behavior to the FBX one.
- Assets: Added warnings for unsupported shaders features from materials (emissive, bump and reflection maps).
- Engine: Enhance Entity/EntityComponent API. Add collection initializers for Entity. Add easier method for getting a component.
- Shaders: Specular intensity, power and color are compositions, thus can be values or textures. This reflects the changes done in the FBX importer.
- Studio: Double-clicking on an Effect shader or an Effect compositor will open the shader file with a text editor (customizable in the settings).
- Studio: It is now possible to open an asset file either with a text editor, or any custom application associated with the file extension.
- Studio: Open the source file of an asset (texture, model...) in the context menu.

#### Issues fixed
- iOS: Paradox is now compatible with Xamarin iOS 8.2+ (Xamarin 3.7+).
- Graphics: Allow SpriteBatch to use a custom effect ([#30](https://github.com/SiliconStudio/paradox/issues/30)).
- Graphics: Use only space character in all pdxfx/pdxsl shaders ([#27](https://github.com/SiliconStudio/paradox/issues/27)).
- Shaders: Fix SV_InstanceID type in ShaderBase ([#33](https://github.com/SiliconStudio/paradox/issues/33)).
- Studio: Some windows being bigger than the screen resolution on low-resolution displays.
- Studio: Assets that were just added in the selected directory (from import, new, undo-delete...) were incorrectly sorted.
- Studio: SpriteGroup build is no longer re-triggered on selection.

___

### Version 1.0.0-alpha09

Release date: 2014/09/24

#### New Features
- Assets: Shadow map size is now editable on the LightComponent.
- Core: Add ray/rectangle collision method.
- Graphics: Variance shadow maps are available. HorizontalVsmBlur and VerticalVsmBlur need to be added to the pdxfxlib file of the project.
- Graphics: Shadow maps can be forced to fit within a constrained budget. Any extra shadow map won't be rendered. The processor classes handling this behavior are LightShadowProcessorWithBudget and LightShadowProcessorDefaultBudget. To ignore a shadow map budget, use DynamicLightShadowProcessor class. The later class is the one currently used in the Default pipeline.
- UI: Add a new UI element: Border.

#### Enhancements
- Assets: Rename ShadowMapLevelCount into ShadowMapCascadeCount in LightComponent.
- Assets: Rename LevelCount into CascadeCount in pdxlightconf files.
- Assets: Better handling of assets loading with same ids.
- Engine: Improve performance of shader live reloading (Windows only).
- Engine: Change some keys names from LightingKeys.xxx to Lighting.xxx. Xamarin Studio in the Settings menu to open solutions ([#5](https://github.com/SiliconStudio/paradox/issues/5)) ([#14](https://github.com/SiliconStudio/paradox/issues/14)).
- Engine: Raw asset files are now accessible through either AssetManager.FileProvider, or /asset mount point in VirtualFileSystem.
- Graphics: Share shadow map textures between shadow maps when it is possible.
- Studio: Add possibility to zoom in/out in asset preview with mouse wheel.
- Studio: Allow to choose between Default, Visual Studio 2012, Visual Studio 2013 and Xamarin Studio.
- Studio: Automatically reload source images in the Sprite Editor when they are modified by an external tool.
- Studio: Main window won't go outside of the screen even on small resolution ([#13](https://github.com/SiliconStudio/paradox/issues/13))
- Studio: Save window size and state (maximized/normal) when exiting, and restore these properties at next launch
- Studio: Improve zooming in the texture/sprite previews.
- Studio: Can undock Preview to a float window
- UI: Perform hit tests on CPU instead of GPU to avoid GPU stalls.
- UI: Add background color property to UIElement
- UI: Merge the different UI batch into a single one (more efficient batching and cleaner code).

#### Issues fixed
- Graphics: Fix false positive effect change detection.
- Graphics: Fix deferred lighting when there are several directional lights, spot lights or directional lights with shadow.
- Input: Support gamepads reconnected ([#20](https://github.com/SiliconStudio/paradox/issues/20))
- Input: Breaking changes: Input.KeyPressed, KeyReleased removed in favour of Input.KeyEvents ([#21](https://github.com/SiliconStudio/paradox/issues/21)).
- Input: Filter ALT, F10 keys to avoid blocking game ([#21](https://github.com/SiliconStudio/paradox/issues/21)).
- Shaders: Use light intensity in deferred lighting.
- Studio: Fix creating game or sample with spaces and dot in project name, and dots in namespace ([#16](https://github.com/SiliconStudio/paradox/issues/16)) ([#17](https://github.com/SiliconStudio/paradox/issues/17)).
- Studio: Fix settings saving when Paradox is installed on another drive that the system drive.
- Studio: Avoid compiling reference assemblies when creating a game from a sample template.
- Studio: Fix the time scale being sometimes incorrect in the animation preview.
- Studio: Fix crash when removing assets after being imported to a project
- UI: Fix elements' linear sampling by adding W component to vertices in UIImageBatch.
- UI: Fix TextBlock text positioning when element is rotated in 3D.
- Visual Studio Package: Ignore projects that are not C# (csproj) ([#18](https://github.com/SiliconStudio/paradox/issues/18)).
- Visual Studio Package: .pdxsl/.pdxfx code generator was not working without VSSDK installed ([#19](https://github.com/SiliconStudio/paradox/issues/19)).

___

### Version 1.0.0-alpha08

Release date: 2014/09/10

#### New Features
- Materials: detection of emissive maps when importing a FBX file.

#### Enhancements
- Assets: Lighting configurations are compiled like any assets which will speed up project compilation, especially when a configuration is shared by many meshes.
- Graphics: Better internal management of shadow maps. Once the entity the light is attached to is removed from the EntitySystem, the associated shadow map is destroyed. Turning a light on and off does not destroy it.
- Graphics: Add support in BatchBase for any vertex input layout and dynamic index buffer.
- Graphics: Add support for Texture.GetData with DoNotWait (desktop)
- Graphics: Better handling of full screen modes listing (desktop)
- Studio: Improve layout of the welcome page
- Studio: Sprite editor instances can be open only once for a given asset, and are properly closed when switching to another solution or if the asset is deleted.
- Studio: Display full MSBuild log when building projects (there were only errors before).
- Studio: Paradox Studio launcher can be moved and minimized.
- UI: Improve grid children measure process (fix some layout bugs).
- Samples: Improve layout of GameMenu sample.

#### Issues fixed
- Engine: Breaking change for GameTime class. Cleanup properties, remove GameTime.ElapsedGameTime/ElapsedUpdateTime and rename to Elapsed/Total.
- Graphics: Switch to fullscreen on desktop is now working properly.
- Graphics: Disabling sync with vertical retrace is now working properly.
- Graphics: Some intermediate render targets and textures weren't correctly destroyed when a renderer was removed.
- Graphics: Intel doesn't seem to support properly feature level 9.x (crash during creation of shader). Now fallbacks to level 10.
- Setup: Fix installation program and allow to change installation directory ([#2](https://github.com/SiliconStudio/paradox/issues/2))
- Studio: Fix "New Game Project" that was generating invalid projects with pdxfxlib files  
- Studio: Build is now correctly reevaluated when Visual Studio projects are changed from outside
- Studio: Some textboxes in the property grid were resetting the value when pressing Ctrl+S just after editing.
- Studio: Some keyboard shortcuts (Ctrl+A, Ctrl+I...) were not working until an asset was selected.
- Studio: The Sprite editor does not lock source image files anymore.
- Studio: Paradox Studio crashed when adding an Effect.Name (or any string) parameter to an Effect Library asset.
- UI: Fix bug in StackPanel measure process when children virtualization is enabled.
- Assets: Fix the problem of StaticSprite asset data not updating when changing the character set source file content.
- Visual Studio: When Paradox version is updated, Visual Studio plugin will now offer to update files so that IntelliSense can refresh its cache ([#10](https://github.com/SiliconStudio/paradox/issues/10)).

___

### Version 1.0.0-alpha07

Release date: 2014/09/04

#### Issues fixed
- Studio: Exiting the Paradox Studio was generating errors.

___

### Version 1.0.0-alpha06

Release date: 2014/09/04

#### New Features
- Integrated release notes in the welcome menu.
- Welcome to the new workspace!
- Integrate release notes in the new workspace.
- Engine: Reload automatically shaders at runtime when they are modified on the disk (Windows only).
- Shaders: New DiscardTransparentThreshold shader. Set the threshold below the one a pixel will be discarded.
- Shaders: New shaders dealing with normal and tangent skinning.
- Materials: Add UseTransparentMask parameter key in material to disable alpha blending and use the alpha channel as a mask of the texture. Use AlphaDiscardThreshold parameter key to set the desired threshold below the one a pixel will be discarded.
- Assets: Support for `TGA` and `PSD` files for textures.
- UI: Add horizontally align text in EditText using property TextAlignment.
- UI: Add mouse wheel delta value since last frame using property `IInputManager.MouseWheelDelta`.
- UI: Add image stretch type `StretchType.FillOnStretch` and modify `StretchType.Fill` behavior (previous `StretchType.Fill` mode is now implemented by `StretchType.FillOnStretch`).

#### Enhancements
- General: Visual Studio Express 2013 can now open Paradox Projects (with some limitations) ([#4](https://github.com/SiliconStudio/paradox/issues/4))
- Engine: Change default Windows output type to Windows Application ([#8](https://github.com/SiliconStudio/paradox/issues/8)): By default, a console is only opened when there is a message, assemblies are created in debug and the debugger is not attached.
- Engine: Add anisotropic texture filtering on mobile platforms that support it.
- Sample: AnimatedModel. Add lighting to the model. Use default Paradox pre defined shaders.
- Sample: ForwardLighting. Add transparent meshes.
- Sample: Set the same orientation for all samples on Android.
- Studio: Modal windows are not displayed in the taskbar anymore
- Studio: Improvement in the sprite editor: possibility to drop image files in the interface, improved region selection rectangle.
- Studio: Performance improvement in the editor, particularly in the sprite editor
- UI: Allow 0-sized strip definition in Grid.
- UI: Allow mixing of relative/absolute element positioning in Canvas.
- UI: Allow user to modify values of the UIRenderingContext.

#### Issues fixed
- Build: Android project fails to build ([#3](https://github.com/SiliconStudio/paradox/issues/3))
- Studio: GameStudio was using 100% of one CPU core ([#1](https://github.com/SiliconStudio/paradox/issues/1))
- Studio: Splash Screen always on top ([#6](https://github.com/SiliconStudio/paradox/issues/6))
- Studio: Fix GameStudio crash when importing assets using the add files button ([#9](https://github.com/SiliconStudio/paradox/issues/9))
- Studio: Build log is now displaying build feedback
- Studio: Fixed the Hue selection in the color picker
- Engine: Reduce effect change detection footprint (for example when changing the lighting configuration of the scene).
- Engine: Reuse rendering states.
- Shaders: Fix incorrect normal and tangent skinning in shaders.
- Shaders: Fix converter Hlsl to Glsl.
- Input: Fixed InputManager crash when window size is reach 0.
- Physics: Character Controller was not working properly on iOS.
