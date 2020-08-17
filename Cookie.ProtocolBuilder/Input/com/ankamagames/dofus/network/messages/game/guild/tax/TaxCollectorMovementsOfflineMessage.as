package com.ankamagames.dofus.network.messages.game.guild.tax
{
   import com.ankamagames.dofus.network.types.game.guild.tax.TaxCollectorMovement;
   import com.ankamagames.jerakine.network.CustomDataWrapper;
   import com.ankamagames.jerakine.network.ICustomDataInput;
   import com.ankamagames.jerakine.network.ICustomDataOutput;
   import com.ankamagames.jerakine.network.INetworkMessage;
   import com.ankamagames.jerakine.network.NetworkMessage;
   import com.ankamagames.jerakine.network.utils.FuncTree;
   import flash.utils.ByteArray;
   
   [Trusted]
   public class TaxCollectorMovementsOfflineMessage extends NetworkMessage implements INetworkMessage
   {
      
      public static const protocolId:uint = 6611;
       
      
      private var _isInitialized:Boolean = false;
      
      public var movements:Vector.<TaxCollectorMovement>;
      
      private var _movementstree:FuncTree;
      
      public function TaxCollectorMovementsOfflineMessage()
      {
         this.movements = new Vector.<TaxCollectorMovement>();
         super();
      }
      
      override public function get isInitialized() : Boolean
      {
         return this._isInitialized;
      }
      
      override public function getMessageId() : uint
      {
         return 6611;
      }
      
      public function initTaxCollectorMovementsOfflineMessage(param1:Vector.<TaxCollectorMovement> = null) : TaxCollectorMovementsOfflineMessage
      {
         this.movements = param1;
         this._isInitialized = true;
         return this;
      }
      
      override public function reset() : void
      {
         this.movements = new Vector.<TaxCollectorMovement>();
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
         this.serializeAs_TaxCollectorMovementsOfflineMessage(param1);
      }
      
      public function serializeAs_TaxCollectorMovementsOfflineMessage(param1:ICustomDataOutput) : void
      {
         param1.writeShort(this.movements.length);
         var _loc2_:uint = 0;
         while(_loc2_ < this.movements.length)
         {
            (this.movements[_loc2_] as TaxCollectorMovement).serializeAs_TaxCollectorMovement(param1);
            _loc2_++;
         }
      }
      
      public function deserialize(param1:ICustomDataInput) : void
      {
         this.deserializeAs_TaxCollectorMovementsOfflineMessage(param1);
      }
      
      public function deserializeAs_TaxCollectorMovementsOfflineMessage(param1:ICustomDataInput) : void
      {
         var _loc4_:TaxCollectorMovement = null;
         var _loc2_:uint = param1.readUnsignedShort();
         var _loc3_:uint = 0;
         while(_loc3_ < _loc2_)
         {
            _loc4_ = new TaxCollectorMovement();
            _loc4_.deserialize(param1);
            this.movements.push(_loc4_);
            _loc3_++;
         }
      }
      
      public function deserializeAsync(param1:FuncTree) : void
      {
         this.deserializeAsyncAs_TaxCollectorMovementsOfflineMessage(param1);
      }
      
      public function deserializeAsyncAs_TaxCollectorMovementsOfflineMessage(param1:FuncTree) : void
      {
         this._movementstree = param1.addChild(this._movementstreeFunc);
      }
      
      private function _movementstreeFunc(param1:ICustomDataInput) : void
      {
         var _loc2_:uint = param1.readUnsignedShort();
         var _loc3_:uint = 0;
         while(_loc3_ < _loc2_)
         {
            this._movementstree.addChild(this._movementsFunc);
            _loc3_++;
         }
      }
      
      private function _movementsFunc(param1:ICustomDataInput) : void
      {
         var _loc2_:TaxCollectorMovement = new TaxCollectorMovement();
         _loc2_.deserialize(param1);
         this.movements.push(_loc2_);
      }
   }
}
