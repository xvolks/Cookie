package com.ankamagames.dofus.network.types.game.context.roleplay
{
   import com.ankamagames.dofus.network.ProtocolTypeManager;
   import com.ankamagames.dofus.network.types.game.context.EntityDispositionInformations;
   import com.ankamagames.dofus.network.types.game.look.EntityLook;
   import com.ankamagames.dofus.network.types.game.prism.PrismInformation;
   import com.ankamagames.jerakine.network.ICustomDataInput;
   import com.ankamagames.jerakine.network.ICustomDataOutput;
   import com.ankamagames.jerakine.network.INetworkType;
   import com.ankamagames.jerakine.network.utils.FuncTree;
   
   public class GameRolePlayPrismInformations extends GameRolePlayActorInformations implements INetworkType
   {
      
      public static const protocolId:uint = 161;
       
      
      public var prism:PrismInformation;
      
      private var _prismtree:FuncTree;
      
      public function GameRolePlayPrismInformations()
      {
         this.prism = new PrismInformation();
         super();
      }
      
      override public function getTypeId() : uint
      {
         return 161;
      }
      
      public function initGameRolePlayPrismInformations(param1:Number = 0, param2:EntityLook = null, param3:EntityDispositionInformations = null, param4:PrismInformation = null) : GameRolePlayPrismInformations
      {
         super.initGameRolePlayActorInformations(param1,param2,param3);
         this.prism = param4;
         return this;
      }
      
      override public function reset() : void
      {
         super.reset();
         this.prism = new PrismInformation();
      }
      
      override public function serialize(param1:ICustomDataOutput) : void
      {
         this.serializeAs_GameRolePlayPrismInformations(param1);
      }
      
      public function serializeAs_GameRolePlayPrismInformations(param1:ICustomDataOutput) : void
      {
         super.serializeAs_GameRolePlayActorInformations(param1);
         param1.writeShort(this.prism.getTypeId());
         this.prism.serialize(param1);
      }
      
      override public function deserialize(param1:ICustomDataInput) : void
      {
         this.deserializeAs_GameRolePlayPrismInformations(param1);
      }
      
      public function deserializeAs_GameRolePlayPrismInformations(param1:ICustomDataInput) : void
      {
         super.deserialize(param1);
         var _loc2_:uint = param1.readUnsignedShort();
         this.prism = ProtocolTypeManager.getInstance(PrismInformation,_loc2_);
         this.prism.deserialize(param1);
      }
      
      override public function deserializeAsync(param1:FuncTree) : void
      {
         this.deserializeAsyncAs_GameRolePlayPrismInformations(param1);
      }
      
      public function deserializeAsyncAs_GameRolePlayPrismInformations(param1:FuncTree) : void
      {
         super.deserializeAsync(param1);
         this._prismtree = param1.addChild(this._prismtreeFunc);
      }
      
      private function _prismtreeFunc(param1:ICustomDataInput) : void
      {
         var _loc2_:uint = param1.readUnsignedShort();
         this.prism = ProtocolTypeManager.getInstance(PrismInformation,_loc2_);
         this.prism.deserializeAsync(this._prismtree);
      }
   }
}
