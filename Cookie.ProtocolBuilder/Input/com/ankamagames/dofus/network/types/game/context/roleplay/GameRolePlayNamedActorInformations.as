package com.ankamagames.dofus.network.types.game.context.roleplay
{
   import com.ankamagames.dofus.network.types.game.context.EntityDispositionInformations;
   import com.ankamagames.dofus.network.types.game.look.EntityLook;
   import com.ankamagames.jerakine.network.ICustomDataInput;
   import com.ankamagames.jerakine.network.ICustomDataOutput;
   import com.ankamagames.jerakine.network.INetworkType;
   import com.ankamagames.jerakine.network.utils.FuncTree;
   
   public class GameRolePlayNamedActorInformations extends GameRolePlayActorInformations implements INetworkType
   {
      
      public static const protocolId:uint = 154;
       
      
      public var name:String = "";
      
      public function GameRolePlayNamedActorInformations()
      {
         super();
      }
      
      override public function getTypeId() : uint
      {
         return 154;
      }
      
      public function initGameRolePlayNamedActorInformations(param1:Number = 0, param2:EntityLook = null, param3:EntityDispositionInformations = null, param4:String = "") : GameRolePlayNamedActorInformations
      {
         super.initGameRolePlayActorInformations(param1,param2,param3);
         this.name = param4;
         return this;
      }
      
      override public function reset() : void
      {
         super.reset();
         this.name = "";
      }
      
      override public function serialize(param1:ICustomDataOutput) : void
      {
         this.serializeAs_GameRolePlayNamedActorInformations(param1);
      }
      
      public function serializeAs_GameRolePlayNamedActorInformations(param1:ICustomDataOutput) : void
      {
         super.serializeAs_GameRolePlayActorInformations(param1);
         param1.writeUTF(this.name);
      }
      
      override public function deserialize(param1:ICustomDataInput) : void
      {
         this.deserializeAs_GameRolePlayNamedActorInformations(param1);
      }
      
      public function deserializeAs_GameRolePlayNamedActorInformations(param1:ICustomDataInput) : void
      {
         super.deserialize(param1);
         this._nameFunc(param1);
      }
      
      override public function deserializeAsync(param1:FuncTree) : void
      {
         this.deserializeAsyncAs_GameRolePlayNamedActorInformations(param1);
      }
      
      public function deserializeAsyncAs_GameRolePlayNamedActorInformations(param1:FuncTree) : void
      {
         super.deserializeAsync(param1);
         param1.addChild(this._nameFunc);
      }
      
      private function _nameFunc(param1:ICustomDataInput) : void
      {
         this.name = param1.readUTF();
      }
   }
}
