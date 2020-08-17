package com.ankamagames.dofus.network.types.game.context.roleplay
{
   import com.ankamagames.dofus.network.ProtocolTypeManager;
   import com.ankamagames.dofus.network.types.game.context.EntityDispositionInformations;
   import com.ankamagames.dofus.network.types.game.look.EntityLook;
   import com.ankamagames.jerakine.network.ICustomDataInput;
   import com.ankamagames.jerakine.network.ICustomDataOutput;
   import com.ankamagames.jerakine.network.INetworkType;
   import com.ankamagames.jerakine.network.utils.FuncTree;
   
   public class GameRolePlayHumanoidInformations extends GameRolePlayNamedActorInformations implements INetworkType
   {
      
      public static const protocolId:uint = 159;
       
      
      public var humanoidInfo:HumanInformations;
      
      public var accountId:uint = 0;
      
      private var _humanoidInfotree:FuncTree;
      
      public function GameRolePlayHumanoidInformations()
      {
         this.humanoidInfo = new HumanInformations();
         super();
      }
      
      override public function getTypeId() : uint
      {
         return 159;
      }
      
      public function initGameRolePlayHumanoidInformations(param1:Number = 0, param2:EntityLook = null, param3:EntityDispositionInformations = null, param4:String = "", param5:HumanInformations = null, param6:uint = 0) : GameRolePlayHumanoidInformations
      {
         super.initGameRolePlayNamedActorInformations(param1,param2,param3,param4);
         this.humanoidInfo = param5;
         this.accountId = param6;
         return this;
      }
      
      override public function reset() : void
      {
         super.reset();
         this.humanoidInfo = new HumanInformations();
      }
      
      override public function serialize(param1:ICustomDataOutput) : void
      {
         this.serializeAs_GameRolePlayHumanoidInformations(param1);
      }
      
      public function serializeAs_GameRolePlayHumanoidInformations(param1:ICustomDataOutput) : void
      {
         super.serializeAs_GameRolePlayNamedActorInformations(param1);
         param1.writeShort(this.humanoidInfo.getTypeId());
         this.humanoidInfo.serialize(param1);
         if(this.accountId < 0)
         {
            throw new Error("Forbidden value (" + this.accountId + ") on element accountId.");
         }
         param1.writeInt(this.accountId);
      }
      
      override public function deserialize(param1:ICustomDataInput) : void
      {
         this.deserializeAs_GameRolePlayHumanoidInformations(param1);
      }
      
      public function deserializeAs_GameRolePlayHumanoidInformations(param1:ICustomDataInput) : void
      {
         super.deserialize(param1);
         var _loc2_:uint = param1.readUnsignedShort();
         this.humanoidInfo = ProtocolTypeManager.getInstance(HumanInformations,_loc2_);
         this.humanoidInfo.deserialize(param1);
         this._accountIdFunc(param1);
      }
      
      override public function deserializeAsync(param1:FuncTree) : void
      {
         this.deserializeAsyncAs_GameRolePlayHumanoidInformations(param1);
      }
      
      public function deserializeAsyncAs_GameRolePlayHumanoidInformations(param1:FuncTree) : void
      {
         super.deserializeAsync(param1);
         this._humanoidInfotree = param1.addChild(this._humanoidInfotreeFunc);
         param1.addChild(this._accountIdFunc);
      }
      
      private function _humanoidInfotreeFunc(param1:ICustomDataInput) : void
      {
         var _loc2_:uint = param1.readUnsignedShort();
         this.humanoidInfo = ProtocolTypeManager.getInstance(HumanInformations,_loc2_);
         this.humanoidInfo.deserializeAsync(this._humanoidInfotree);
      }
      
      private function _accountIdFunc(param1:ICustomDataInput) : void
      {
         this.accountId = param1.readInt();
         if(this.accountId < 0)
         {
            throw new Error("Forbidden value (" + this.accountId + ") on element of GameRolePlayHumanoidInformations.accountId.");
         }
      }
   }
}
