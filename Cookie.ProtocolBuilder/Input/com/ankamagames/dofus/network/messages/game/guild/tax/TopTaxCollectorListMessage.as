package com.ankamagames.dofus.network.messages.game.guild.tax
{
   import com.ankamagames.dofus.network.types.game.guild.tax.TaxCollectorInformations;
   import com.ankamagames.jerakine.network.CustomDataWrapper;
   import com.ankamagames.jerakine.network.ICustomDataInput;
   import com.ankamagames.jerakine.network.ICustomDataOutput;
   import com.ankamagames.jerakine.network.INetworkMessage;
   import com.ankamagames.jerakine.network.utils.FuncTree;
   import flash.utils.ByteArray;
   
   [Trusted]
   public class TopTaxCollectorListMessage extends AbstractTaxCollectorListMessage implements INetworkMessage
   {
      
      public static const protocolId:uint = 6565;
       
      
      private var _isInitialized:Boolean = false;
      
      public var isDungeon:Boolean = false;
      
      public function TopTaxCollectorListMessage()
      {
         super();
      }
      
      override public function get isInitialized() : Boolean
      {
         return super.isInitialized && this._isInitialized;
      }
      
      override public function getMessageId() : uint
      {
         return 6565;
      }
      
      public function initTopTaxCollectorListMessage(param1:Vector.<TaxCollectorInformations> = null, param2:Boolean = false) : TopTaxCollectorListMessage
      {
         super.initAbstractTaxCollectorListMessage(param1);
         this.isDungeon = param2;
         this._isInitialized = true;
         return this;
      }
      
      override public function reset() : void
      {
         super.reset();
         this.isDungeon = false;
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
      
      override public function serialize(param1:ICustomDataOutput) : void
      {
         this.serializeAs_TopTaxCollectorListMessage(param1);
      }
      
      public function serializeAs_TopTaxCollectorListMessage(param1:ICustomDataOutput) : void
      {
         super.serializeAs_AbstractTaxCollectorListMessage(param1);
         param1.writeBoolean(this.isDungeon);
      }
      
      override public function deserialize(param1:ICustomDataInput) : void
      {
         this.deserializeAs_TopTaxCollectorListMessage(param1);
      }
      
      public function deserializeAs_TopTaxCollectorListMessage(param1:ICustomDataInput) : void
      {
         super.deserialize(param1);
         this._isDungeonFunc(param1);
      }
      
      override public function deserializeAsync(param1:FuncTree) : void
      {
         this.deserializeAsyncAs_TopTaxCollectorListMessage(param1);
      }
      
      public function deserializeAsyncAs_TopTaxCollectorListMessage(param1:FuncTree) : void
      {
         super.deserializeAsync(param1);
         param1.addChild(this._isDungeonFunc);
      }
      
      private function _isDungeonFunc(param1:ICustomDataInput) : void
      {
         this.isDungeon = param1.readBoolean();
      }
   }
}
