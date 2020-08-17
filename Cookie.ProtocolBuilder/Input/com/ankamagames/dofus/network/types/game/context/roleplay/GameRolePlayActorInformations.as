package com.ankamagames.dofus.network.types.game.context.roleplay
{
   import com.ankamagames.dofus.network.types.game.context.EntityDispositionInformations;
   import com.ankamagames.dofus.network.types.game.context.GameContextActorInformations;
   import com.ankamagames.dofus.network.types.game.look.EntityLook;
   import com.ankamagames.jerakine.network.ICustomDataInput;
   import com.ankamagames.jerakine.network.ICustomDataOutput;
   import com.ankamagames.jerakine.network.INetworkType;
   import com.ankamagames.jerakine.network.utils.FuncTree;
   
   public class GameRolePlayActorInformations extends GameContextActorInformations implements INetworkType
   {
      
      public static const protocolId:uint = 141;
       
      
      public function GameRolePlayActorInformations()
      {
         super();
      }
      
      override public function getTypeId() : uint
      {
         return 141;
      }
      
      public function initGameRolePlayActorInformations(param1:Number = 0, param2:EntityLook = null, param3:EntityDispositionInformations = null) : GameRolePlayActorInformations
      {
         super.initGameContextActorInformations(param1,param2,param3);
         return this;
      }
      
      override public function reset() : void
      {
         super.reset();
      }
      
      override public function serialize(param1:ICustomDataOutput) : void
      {
         this.serializeAs_GameRolePlayActorInformations(param1);
      }
      
      public function serializeAs_GameRolePlayActorInformations(param1:ICustomDataOutput) : void
      {
         super.serializeAs_GameContextActorInformations(param1);
      }
      
      override public function deserialize(param1:ICustomDataInput) : void
      {
         this.deserializeAs_GameRolePlayActorInformations(param1);
      }
      
      public function deserializeAs_GameRolePlayActorInformations(param1:ICustomDataInput) : void
      {
         super.deserialize(param1);
      }
      
      override public function deserializeAsync(param1:FuncTree) : void
      {
         this.deserializeAsyncAs_GameRolePlayActorInformations(param1);
      }
      
      public function deserializeAsyncAs_GameRolePlayActorInformations(param1:FuncTree) : void
      {
         super.deserializeAsync(param1);
      }
   }
}
