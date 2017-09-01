package com.ankamagames.dofus.network.messages.game.guild.tax
{
   import com.ankamagames.jerakine.network.CustomDataWrapper;
   import com.ankamagames.jerakine.network.ICustomDataInput;
   import com.ankamagames.jerakine.network.ICustomDataOutput;
   import com.ankamagames.jerakine.network.INetworkMessage;
   import com.ankamagames.jerakine.network.NetworkMessage;
   import com.ankamagames.jerakine.network.utils.FuncTree;
   import flash.utils.ByteArray;
   
   [Trusted]
   public class GameRolePlayTaxCollectorFightRequestMessage extends NetworkMessage implements INetworkMessage
   {
      
      public static const protocolId:uint = 5954;
       
      
      private var _isInitialized:Boolean = false;
      
      public var taxCollectorId:int = 0;
      
      public function GameRolePlayTaxCollectorFightRequestMessage()
      {
         super();
      }
      
      override public function get isInitialized() : Boolean
      {
         return this._isInitialized;
      }
      
      override public function getMessageId() : uint
      {
         return 5954;
      }
      
      public function initGameRolePlayTaxCollectorFightRequestMessage(param1:int = 0) : GameRolePlayTaxCollectorFightRequestMessage
      {
         this.taxCollectorId = param1;
         this._isInitialized = true;
         return this;
      }
      
      override public function reset() : void
      {
         this.taxCollectorId = 0;
         this._isInitialized = false;
      }
      
      override public function pack(param1:ICustomDataOutput) : void
      {
         var _loc2_:ByteArray = new ByteArray();
         this.serialize(new CustomDataWrapper(_loc2_));
         writePacket(param1,this.getMessageId(),_loc2_);
      }
      
      override public function unpack(param1:ICustomDataInput, param2:uint) : void
      {
         this.deserialize(param1);
      }
      
      override public function unpackAsync(param1:ICustomDataInput, param2:uint) : FuncTree
      {
         var _loc3_:FuncTree = new FuncTree();
         _loc3_.setRoot(param1);
         this.deserializeAsync(_loc3_);
         return _loc3_;
      }
      
      public function serialize(param1:ICustomDataOutput) : void
      {
         this.serializeAs_GameRolePlayTaxCollectorFightRequestMessage(param1);
      }
      
      public function serializeAs_GameRolePlayTaxCollectorFightRequestMessage(param1:ICustomDataOutput) : void
      {
         param1.writeInt(this.taxCollectorId);
      }
      
      public function deserialize(param1:ICustomDataInput) : void
      {
         this.deserializeAs_GameRolePlayTaxCollectorFightRequestMessage(param1);
      }
      
      public function deserializeAs_GameRolePlayTaxCollectorFightRequestMessage(param1:ICustomDataInput) : void
      {
         this._taxCollectorIdFunc(param1);
      }
      
      public function deserializeAsync(param1:FuncTree) : void
      {
         this.deserializeAsyncAs_GameRolePlayTaxCollectorFightRequestMessage(param1);
      }
      
      public function deserializeAsyncAs_GameRolePlayTaxCollectorFightRequestMessage(param1:FuncTree) : void
      {
         param1.addChild(this._taxCollectorIdFunc);
      }
      
      private function _taxCollectorIdFunc(param1:ICustomDataInput) : void
      {
         this.taxCollectorId = param1.readInt();
      }
   }
}
