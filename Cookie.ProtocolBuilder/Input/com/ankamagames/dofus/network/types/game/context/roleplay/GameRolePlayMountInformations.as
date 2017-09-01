package com.ankamagames.dofus.network.types.game.context.roleplay
{
   import com.ankamagames.dofus.network.types.game.context.EntityDispositionInformations;
   import com.ankamagames.dofus.network.types.game.look.EntityLook;
   import com.ankamagames.jerakine.network.ICustomDataInput;
   import com.ankamagames.jerakine.network.ICustomDataOutput;
   import com.ankamagames.jerakine.network.INetworkType;
   import com.ankamagames.jerakine.network.utils.FuncTree;
   
   public class GameRolePlayMountInformations extends GameRolePlayNamedActorInformations implements INetworkType
   {
      
      public static const protocolId:uint = 180;
       
      
      public var ownerName:String = "";
      
      public var level:uint = 0;
      
      public function GameRolePlayMountInformations()
      {
         super();
      }
      
      override public function getTypeId() : uint
      {
         return 180;
      }
      
      public function initGameRolePlayMountInformations(param1:Number = 0, param2:EntityLook = null, param3:EntityDispositionInformations = null, param4:String = "", param5:String = "", param6:uint = 0) : GameRolePlayMountInformations
      {
         super.initGameRolePlayNamedActorInformations(param1,param2,param3,param4);
         this.ownerName = param5;
         this.level = param6;
         return this;
      }
      
      override public function reset() : void
      {
         super.reset();
         this.ownerName = "";
         this.level = 0;
      }
      
      override public function serialize(param1:ICustomDataOutput) : void
      {
         this.serializeAs_GameRolePlayMountInformations(param1);
      }
      
      public function serializeAs_GameRolePlayMountInformations(param1:ICustomDataOutput) : void
      {
         super.serializeAs_GameRolePlayNamedActorInformations(param1);
         param1.writeUTF(this.ownerName);
         if(this.level < 0 || this.level > 255)
         {
            throw new Error("Forbidden value (" + this.level + ") on element level.");
         }
         param1.writeByte(this.level);
      }
      
      override public function deserialize(param1:ICustomDataInput) : void
      {
         this.deserializeAs_GameRolePlayMountInformations(param1);
      }
      
      public function deserializeAs_GameRolePlayMountInformations(param1:ICustomDataInput) : void
      {
         super.deserialize(param1);
         this._ownerNameFunc(param1);
         this._levelFunc(param1);
      }
      
      override public function deserializeAsync(param1:FuncTree) : void
      {
         this.deserializeAsyncAs_GameRolePlayMountInformations(param1);
      }
      
      public function deserializeAsyncAs_GameRolePlayMountInformations(param1:FuncTree) : void
      {
         super.deserializeAsync(param1);
         param1.addChild(this._ownerNameFunc);
         param1.addChild(this._levelFunc);
      }
      
      private function _ownerNameFunc(param1:ICustomDataInput) : void
      {
         this.ownerName = param1.readUTF();
      }
      
      private function _levelFunc(param1:ICustomDataInput) : void
      {
         this.level = param1.readUnsignedByte();
         if(this.level < 0 || this.level > 255)
         {
            throw new Error("Forbidden value (" + this.level + ") on element of GameRolePlayMountInformations.level.");
         }
      }
   }
}
