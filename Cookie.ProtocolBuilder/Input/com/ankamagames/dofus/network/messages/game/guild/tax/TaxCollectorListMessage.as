package com.ankamagames.dofus.network.messages.game.guild.tax
{
   import com.ankamagames.dofus.network.types.game.guild.tax.TaxCollectorFightersInformation;
   import com.ankamagames.dofus.network.types.game.guild.tax.TaxCollectorInformations;
   import com.ankamagames.jerakine.network.CustomDataWrapper;
   import com.ankamagames.jerakine.network.ICustomDataInput;
   import com.ankamagames.jerakine.network.ICustomDataOutput;
   import com.ankamagames.jerakine.network.INetworkMessage;
   import com.ankamagames.jerakine.network.utils.FuncTree;
   import flash.utils.ByteArray;
   
   [Trusted]
   public class TaxCollectorListMessage extends AbstractTaxCollectorListMessage implements INetworkMessage
   {
      
      public static const protocolId:uint = 5930;
       
      
      private var _isInitialized:Boolean = false;
      
      public var nbcollectorMax:uint = 0;
      
      public var fightersInformations:Vector.<TaxCollectorFightersInformation>;
      
      private var _fightersInformationstree:FuncTree;
      
      public function TaxCollectorListMessage()
      {
         this.fightersInformations = new Vector.<TaxCollectorFightersInformation>();
         super();
      }
      
      override public function get isInitialized() : Boolean
      {
         return super.isInitialized && this._isInitialized;
      }
      
      override public function getMessageId() : uint
      {
         return 5930;
      }
      
      public function initTaxCollectorListMessage(param1:Vector.<TaxCollectorInformations> = null, param2:uint = 0, param3:Vector.<TaxCollectorFightersInformation> = null) : TaxCollectorListMessage
      {
         super.initAbstractTaxCollectorListMessage(param1);
         this.nbcollectorMax = param2;
         this.fightersInformations = param3;
         this._isInitialized = true;
         return this;
      }
      
      override public function reset() : void
      {
         super.reset();
         this.nbcollectorMax = 0;
         this.fightersInformations = new Vector.<TaxCollectorFightersInformation>();
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
         this.serializeAs_TaxCollectorListMessage(param1);
      }
      
      public function serializeAs_TaxCollectorListMessage(param1:ICustomDataOutput) : void
      {
         super.serializeAs_AbstractTaxCollectorListMessage(param1);
         if(this.nbcollectorMax < 0)
         {
            throw new Error("Forbidden value (" + this.nbcollectorMax + ") on element nbcollectorMax.");
         }
         param1.writeByte(this.nbcollectorMax);
         param1.writeShort(this.fightersInformations.length);
         var _loc2_:uint = 0;
         while(_loc2_ < this.fightersInformations.length)
         {
            (this.fightersInformations[_loc2_] as TaxCollectorFightersInformation).serializeAs_TaxCollectorFightersInformation(param1);
            _loc2_++;
         }
      }
      
      override public function deserialize(param1:ICustomDataInput) : void
      {
         this.deserializeAs_TaxCollectorListMessage(param1);
      }
      
      public function deserializeAs_TaxCollectorListMessage(param1:ICustomDataInput) : void
      {
         var _loc4_:TaxCollectorFightersInformation = null;
         super.deserialize(param1);
         this._nbcollectorMaxFunc(param1);
         var _loc2_:uint = param1.readUnsignedShort();
         var _loc3_:uint = 0;
         while(_loc3_ < _loc2_)
         {
            _loc4_ = new TaxCollectorFightersInformation();
            _loc4_.deserialize(param1);
            this.fightersInformations.push(_loc4_);
            _loc3_++;
         }
      }
      
      override public function deserializeAsync(param1:FuncTree) : void
      {
         this.deserializeAsyncAs_TaxCollectorListMessage(param1);
      }
      
      public function deserializeAsyncAs_TaxCollectorListMessage(param1:FuncTree) : void
      {
         super.deserializeAsync(param1);
         param1.addChild(this._nbcollectorMaxFunc);
         this._fightersInformationstree = param1.addChild(this._fightersInformationstreeFunc);
      }
      
      private function _nbcollectorMaxFunc(param1:ICustomDataInput) : void
      {
         this.nbcollectorMax = param1.readByte();
         if(this.nbcollectorMax < 0)
         {
            throw new Error("Forbidden value (" + this.nbcollectorMax + ") on element of TaxCollectorListMessage.nbcollectorMax.");
         }
      }
      
      private function _fightersInformationstreeFunc(param1:ICustomDataInput) : void
      {
         var _loc2_:uint = param1.readUnsignedShort();
         var _loc3_:uint = 0;
         while(_loc3_ < _loc2_)
         {
            this._fightersInformationstree.addChild(this._fightersInformationsFunc);
            _loc3_++;
         }
      }
      
      private function _fightersInformationsFunc(param1:ICustomDataInput) : void
      {
         var _loc2_:TaxCollectorFightersInformation = new TaxCollectorFightersInformation();
         _loc2_.deserialize(param1);
         this.fightersInformations.push(_loc2_);
      }
   }
}
